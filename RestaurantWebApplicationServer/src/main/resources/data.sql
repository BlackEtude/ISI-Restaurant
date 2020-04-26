INSERT INTO DELIVERY_POINTS
    (address_street, address_postal_code, address_city, address_country, open_date_time, close_date_time, latitude, longitude)
VALUES
    ('ul. Klimasa 37b/3', '50-515', 'Wrocław', 'Polska', '11:00', '22:00', '51.080192', '17.063192'),
    ('ul. Jedności Narodowej 122a ', '50-301', 'Wrocław', 'Polska', '11:00', '22:00', '51.129598', '17.045638'),
    ('ul. Bulwar Dedala 7a', '54-130', 'Wrocław', 'Polska', '11:00', '22:00', '51.130244', '16.964614'),
    ('ul. Oleska 7', '50-215', 'Wrocław', 'Polska', '11:00', '22:00', '51.167702', '17.133708');

INSERT INTO PRODUCTS
    (description, name, price, photo_location)
VALUES
    ('sos pomidorowy, bazylia, ser', 'Pizza Minimal', '19.00', 'img/pizzas/margherita.jpg'),
    ('sos pomidorowy, pieczarki, ser', 'Pizza Chillout', '21.00', 'img/pizzas/mushroom.jpg'),
    ('sos pomidorowy, szynka, ser', 'Pizza Pop', '22.00', 'img/pizzas/meaty.jpg'),
    ('sos pomidorowy, pieczarki, salami, ser', 'Pizza Salsa', '23.00', 'img/pizzas/pepperoni.jpg'),
    ('sos pomidorowy, pieczarki, ser, szynka', 'Pizza Classic', '23.00', 'img/pizzas/brit.jpg');

INSERT INTO TOPPINGS
    (name, price)
VALUES
    ('szynka', '6.00'),
    ('boczek', '6.00'),
    ('owoce morza', '6.00'),
    ('tuńczyk', '6.00'),
    ('ananas', '5.00'),
    ('cebula', '5.00'),
    ('kukurydza', '5.00'),
    ('papryka', '5.00'),
    ('pieczarki', '5.00'),
    ('rukola', '5.00');