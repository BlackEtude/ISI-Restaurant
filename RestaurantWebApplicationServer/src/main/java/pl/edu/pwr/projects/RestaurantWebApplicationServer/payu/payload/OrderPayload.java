package pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.payload;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.math.BigInteger;
import java.util.ArrayList;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class OrderPayload {
    private String notifyUrl;
    private String customerIp;
    private int merchantPosId;
    private String description;
    private String currencyCode;
    private BigInteger totalAmount;
    private BuyerPayload buyerPayload;
    private ArrayList<ProductPayload> products;
}
