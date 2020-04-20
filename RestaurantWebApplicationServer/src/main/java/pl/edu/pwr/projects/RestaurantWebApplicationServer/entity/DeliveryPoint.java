package pl.edu.pwr.projects.RestaurantWebApplicationServer.entity;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "DELIVERY_POINTS")
public class DeliveryPoint {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;

    private Address address;

    private OpeningHours openingHours;

    private Coordinates coordinates;
}
