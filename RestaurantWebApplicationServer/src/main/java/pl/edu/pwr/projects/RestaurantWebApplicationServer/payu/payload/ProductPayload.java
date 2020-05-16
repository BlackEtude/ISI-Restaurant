package pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.payload;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.math.BigInteger;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class ProductPayload {
    private String name;
    private BigInteger unitPrice;
    private BigInteger quantity;
}
