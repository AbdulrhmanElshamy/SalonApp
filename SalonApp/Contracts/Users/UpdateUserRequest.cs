﻿namespace SalonApp.Contracts.Users;

public record UpdateUserRequest(
    string FirstName,
    string LastName,
    string Email,
    string phone,
    string ShippingAddress
);