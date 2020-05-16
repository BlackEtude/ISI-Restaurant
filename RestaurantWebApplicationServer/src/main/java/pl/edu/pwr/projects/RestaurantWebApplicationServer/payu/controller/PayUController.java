package pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.controller;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.client.RestClientResponseException;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.configuration.PayUConfiguration;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.payload.BuyerPayload;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.payload.OrderPayload;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.payload.OrderResult;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.payload.ProductPayload;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.service.PayUOrderService;

import javax.servlet.http.HttpServletRequest;
import java.math.BigInteger;
import java.util.ArrayList;
import java.util.UUID;

@RestController
public class PayUController {
    private PayUOrderService payUOrderService;

    private PayUConfiguration payUConfiguration;

    public PayUController(PayUOrderService payUOrderService, PayUConfiguration payUConfiguration) {
        this.payUOrderService = payUOrderService;
        this.payUConfiguration = payUConfiguration;
    }

    @GetMapping("/payu")
    public ResponseEntity create() {
        try {
            ProductPayload product = ProductPayload.builder()
                    .name("Wireless Mouse for Laptop")
                    .quantity(new BigInteger(String.valueOf(1)))
                    .unitPrice(new BigInteger(String.valueOf(15000)))
                    .build();

            BuyerPayload buyer = BuyerPayload.builder()
                    .email("john.doe@example.com")
                    .phone("654111654")
                    .firstName("John")
                    .lastName("Doe")
                    .build();

            String url = "http://localhost:8000/order/" + UUID.randomUUID();

            System.out.println(url);
            ArrayList<ProductPayload> products = new ArrayList();
            products.add(product);

            OrderPayload order = OrderPayload.builder()
                    .notifyUrl(url)
                    .customerIp("127.0.0.1")
                    .merchantPosId(Integer.valueOf(payUConfiguration.getClientId()))
                    .description("RTV market")
                    .currencyCode("PLN")
                    .totalAmount(new BigInteger(String.valueOf(15000)))
                    .buyerPayload(buyer)
                    .products(products)
                    .build();

            OrderResult orderResult = payUOrderService.create(order);
            return new ResponseEntity(orderResult, HttpStatus.CREATED);

        } catch (RestClientResponseException r) {
            return new ResponseEntity(r.getMessage(), HttpStatus.BAD_REQUEST);
        }
    }

    @ExceptionHandler(Exception.class)
    public ResponseEntity exceptionFromSystem(HttpServletRequest req, Exception e) {
        return new ResponseEntity<>(e.getMessage(), HttpStatus.INTERNAL_SERVER_ERROR);
    }
}
