namespace CourseWork.Domain;

public class HttpErrors
{
    public const string ChatNotFound = "Чат-комната не найдена.";
    
    public const string UserNotFound = "Пользователь не найден.";
    
    public const string CourseNotFound = "Курс не найден.";
    
    public const string UserIsNotEnrolledForCourse = "Пользователь не подписан на курс.";
    
    public const string FileNotFound = "Файл не найден.";
    
    public const string PostNotFound = "Пост не найден.";
    
    public const string RoleNotFound = "Роль не найдена.";
    
    public const string OldPasswordDoesNotMatch = "Старый пароль не совпадает.";

    public const string PhoneNumberAlreadyExists = "Номер телефона уже занят.";

    public const string InvalidRegistrationData = "Проверьте поля на пустоту.";

    public const string InvalidLoginCredentials = "Проверьте правильность введённых данных.";

    public const string WrongConversationParticipants = "Получатели не найдены.";
    
    public const string AccessDenied = "Доступ воспрещён.";
    
    public const string ReceiverEqualsSender = "Вы не можете написать сами себе.";

    public const string InvalidDataFormat = "Некорректный формат данных!";

    public const string CategoryNotFound = "Категория не найдена!";
    
    public const string LikeAlreadySet = "Дважды поставить лайк нельзя.";
    
    public const string UserAlreadyEnrolledForCourse = "Пользователь уже записан на курс.";
}