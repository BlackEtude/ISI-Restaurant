package pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.service;

import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.util.LinkedMultiValueMap;
import org.springframework.util.MultiValueMap;
import org.springframework.web.client.RestTemplate;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.configuration.PayUConfiguration;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.payload.AuthResult;

@Service
public class PayUAuthService {

    private PayUConfiguration payUConfiguration;

    private RestTemplate restTemplate;

    private AuthResult authResult;

    public PayUAuthService(PayUConfiguration payUConfiguration, RestTemplate restTemplate, AuthResult authResult) {
        this.payUConfiguration = payUConfiguration;
        this.restTemplate = restTemplate;
        this.authResult = authResult;
    }

    public void authorize() {
        String url = prepareUrlAuth();

        HttpEntity request = new HttpEntity<String>("");
        ResponseEntity<AuthResult> authPayload = this.restTemplate.postForEntity(url, request, AuthResult.class);

        this.authResult = authPayload.getBody();

    }

    private String prepareUrlAuth() {
        return new StringBuilder(this.payUConfiguration.getUrlAuth()).
                append("?grant_type=").append(this.payUConfiguration.getGrandType()).
                append("&client_id=").append(this.payUConfiguration.getClientId()).append("&client_secret=").append(this.payUConfiguration.getClientSecret()).
                toString();
    }

    public String getToken() {
        return authResult.getAccess_token();
    }

}
