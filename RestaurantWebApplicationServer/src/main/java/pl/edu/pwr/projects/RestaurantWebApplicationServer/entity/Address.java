package pl.edu.pwr.projects.RestaurantWebApplicationServer.entity;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.Column;
import javax.persistence.Embeddable;
import java.io.Serializable;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
@Embeddable
public class Address implements Serializable {
    @Column(name = "address_street")
    private String street;

    @Column(name = "address_city")
    private String city;

    @Column(name = "address_postal_code")
    private String postalCode;

    @Column(name = "address_country")
    private String country;
}
