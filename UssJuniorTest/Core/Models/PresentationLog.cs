namespace UssJuniorTest.Core.Models;

/// <summary>
/// Представление записи о вождении.
/// </summary>
/// <remarks>Содержит информацию о временных промежутках вождения конкретного человека конкретным авто с информацией о нем и машине.</remarks>
public class PresentationLog : Model
{
    /// <summary>
    /// Объект автомобиля.
    /// </summary>
    public Car Car { get; set; }

    /// <summary>
    /// Объект человека.
    /// </summary>
    public Person Person { get; set; }

    /// <summary>
    /// Старт вождения.
    /// </summary>
    public DateTime StartDateTime { get; set; }

    /// <summary>
    /// Конец вождения.
    /// </summary>
    public DateTime EndDateTime { get; set; }

    /// <summary>
    /// Продолжительность использования автомобиля.
    /// </summary>
    public string UsageTime { get; set; }
}