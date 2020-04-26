package pl.edu.pwr.projects.RestaurantWebApplicationServer.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ResponseStatus;

import javax.persistence.EntityNotFoundException;

@ResponseStatus(code = HttpStatus.NOT_FOUND, reason = "Order not found.")
public class OrderNotFoundException extends EntityNotFoundException {
}
