package pl.edu.pwr.projects.RestaurantWebApplicationServer.payu.payload;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;
import org.springframework.stereotype.Component;

import java.math.BigInteger;

@Data
@Builder
@Component
@NoArgsConstructor
@AllArgsConstructor
public class AuthResult {
    private String access_token;
    private String token_type;
    private BigInteger expires_in;
    private String grant_type;
}
