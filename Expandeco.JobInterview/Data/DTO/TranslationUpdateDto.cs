namespace Expandeco.JobInterview.Data.DTO;

public class TranslationUpdateDto
{
    public int Id { get; set; }
    public string TranslatedText { get; set; }
    public int? AssignedToId { get; set; }
}