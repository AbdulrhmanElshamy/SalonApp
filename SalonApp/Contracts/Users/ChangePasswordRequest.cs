namespace SalonApp.Contracts.Users;

public record ChangePasswordRequest(
    string CurrentPassword,
    string NewPassword
);