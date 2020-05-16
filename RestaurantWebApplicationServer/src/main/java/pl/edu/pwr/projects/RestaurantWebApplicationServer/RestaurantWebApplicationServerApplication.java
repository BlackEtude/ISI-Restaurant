package pl.edu.pwr.projects.RestaurantWebApplicationServer;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.security.oauth2.config.annotation.web.configuration.EnableAuthorizationServer;
import org.springframework.web.client.RestTemplate;

@EnableAuthorizationServer
@SpringBootApplication
public class RestaurantWebApplicationServerApplication {

    public static void main(String[] args) {
        SpringApplication.run(RestaurantWebApplicationServerApplication.class, args);
    }

    @Bean
    public RestTemplate getRestTemplate(){
        return new RestTemplate();
    }
}
