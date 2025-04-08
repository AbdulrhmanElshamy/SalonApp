namespace SalonApp.Contracts.Users;

public record UpdateProfileRequest(
    string FirstName,
    string LastName
);