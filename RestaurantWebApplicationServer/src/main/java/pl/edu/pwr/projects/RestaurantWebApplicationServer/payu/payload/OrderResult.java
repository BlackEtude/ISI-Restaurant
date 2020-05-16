package pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.payload;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class OrderResult {
    private String redirectUri;
    private String orderId;
    private String extOrderId;
}
