package pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.service;

import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestClientResponseException;
import org.springframework.web.client.RestTemplate;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.entity.*;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.configuration.PayUConfiguration;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.payload.BuyerPayload;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.payload.OrderPayload;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.payload.OrderResult;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.payload.ProductPayload;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.ArrayList;
import java.util.UUID;

@Service
public class PayUOrderService {
    private RestTemplate restTemplate;

    private PayUAuthService payUAuthService;

    private PayUConfiguration payUConfiguration;

    public PayUOrderService(RestTemplate restTemplate, PayUAuthService payUAuthService,
                            PayUConfiguration payUConfiguration) {
        this.restTemplate = restTemplate;
        this.payUAuthService = payUAuthService;
        this.payUConfiguration = payUConfiguration;
    }

    public CreatedOrderResponse createPayUOrder(Order order) {
        try {
        ArrayList<ProductPayload> products = new ArrayList();

        for (OrderItem orderItem : order.getOrderItems()) {
            double price = orderItem.getProduct().getPrice();

            for (Topping topping : orderItem.getToppings()) {
                price += topping.getPrice();
            }

            ProductPayload product = ProductPayload.builder()
                    .name(orderItem.getProduct().getName())
                    .quantity(new BigInteger(String.valueOf(1)))
                    .unitPrice(BigDecimal.valueOf(price * 100).toBigInteger())
                    .build();
            products.add(product);
        }

            CustomerData customerData = order.getCustomerData();
            BuyerPayload buyer = BuyerPayload.builder()
                    .email(customerData.getEmailAddress())
                    .phone(customerData.getPhoneNumber())
                    .firstName(customerData.getFirstName())
                    .lastName(customerData.getLastName())
                    .build();

            String url = "http://localhost:8000/order/" + order.getId();

            OrderPayload payUOrder = OrderPayload.builder()
                    .notifyUrl(url)
                    .customerIp(customerData.getIpAddress())
                    .merchantPosId(Integer.valueOf(payUConfiguration.getClientId()))
                    .description("Hotspot Pizza")
                    .currencyCode("PLN")
                    .totalAmount(BigDecimal.valueOf(order.getTotalPrice() * 100).toBigInteger())
                    .buyerPayload(buyer)
                    .products(products)
                    .build();

            OrderResult orderResult = create(payUOrder);

            CreatedOrderResponse createdOrderResponse = CreatedOrderResponse.builder()
                    .order(order)
                    .orderResult(orderResult)
                    .notifyUrl(url)
                    .build();

            return createdOrderResponse;

        } catch (RestClientResponseException r) {
//            return new ResponseEntity(r.getMessage(), HttpStatus.BAD_REQUEST);
            return null;
        }
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
