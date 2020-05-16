package pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.payload;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class BuyerPayload {
    private String email;
    private String phone;
    private String firstName;
    private String lastName;
    private String language = "pl";
}
