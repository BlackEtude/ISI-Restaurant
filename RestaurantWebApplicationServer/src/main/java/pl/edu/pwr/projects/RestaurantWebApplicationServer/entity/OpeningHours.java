package pl.edu.pwr.projects.RestaurantWebApplicationServer.entity;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.Column;
import javax.persistence.Embeddable;
import java.io.Serializable;
import java.time.LocalTime;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Embeddable
public class OpeningHours implements Serializable {

    @Column(name="open_date_time")
    private LocalTime openingHour;

    @Column(name="close_date_time")
    private LocalTime closingHour;
}
