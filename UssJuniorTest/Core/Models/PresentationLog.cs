﻿namespace UssJuniorTest.Core.Models;

/// <summary>
/// Запись о вождении.
/// </summary>
/// <remarks>Содержит информацию о временных промежутках вождения конкретного человека конкретным авто.</remarks>
public class PresentationLog : Model
{
    /// <summary>
    /// Идентификатор автомобиля.
    /// </summary>
    public Car Car { get; set; }

    /// <summary>
    /// Идентификатор человека.
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
}