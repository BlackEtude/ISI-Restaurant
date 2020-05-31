package pl.edu.pwr.projects.RestaurantWebApplicationServer.entity;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;
import pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.payload.OrderResult;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class CreatedOrderResponse {
    Order order;
    OrderResult orderResult;
    String notifyUrl;
}
