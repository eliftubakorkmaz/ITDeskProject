namespace ITDeskServer.DTOs;

public sealed class TicketResponseDto(
    Guid Id,
    string Subject,
    DateTime CreatedDate,
    bool IsOpen);