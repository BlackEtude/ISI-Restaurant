package pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.configuration;

import lombok.Data;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Component;

@Component
@Data
public class PayUConfiguration {
    @Value("${dev.payu.auth.url}")
    private String urlAuth;

    @Value("${dev.payu.auth.grant_type}")
    private String grandType;

    @Value("${dev.payu.auth.clientId}")
    private String clientId;

    @Value("${dev.payu.auth.clientsecret}")
    private String clientSecret;
}
