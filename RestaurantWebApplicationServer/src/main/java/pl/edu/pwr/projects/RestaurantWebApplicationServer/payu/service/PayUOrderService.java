package pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.service;

import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.payload.OrderPayload;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.payload.OrderResult;

@Service
public class PayUOrderService {
    private RestTemplate restTemplate;

    private PayUAuthService payUAuthService;

    public PayUOrderService(RestTemplate restTemplate, PayUAuthService payUAuthService) {
        this.restTemplate = restTemplate;
        this.payUAuthService = payUAuthService;
    }

    public OrderResult create(OrderPayload order) {
        payUAuthService.authorize();

        HttpHeaders headers = new HttpHeaders();
        headers.add("Authorization", "Bearer " + payUAuthService.getToken());
        headers.add("Content-Type", "application/json");

        HttpEntity requestAuth = new HttpEntity<OrderPayload>(order, headers);
        ResponseEntity<OrderResult> orderResponse =
                restTemplate.postForEntity("https://secure.snd.payu.com/api/v2_1/orders", requestAuth, OrderResult.class);
        return orderResponse.getBody();
    }
}
