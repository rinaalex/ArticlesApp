# ArticlesApp
Проект представляет собой REST API сервер, предоставляющий интерфейс для создания и чтения статей, а также для добавления отзывов.
В проекте реализовано 4 конроллера:
- AccountController - предоставляет функции авторизации и регистрации пользователей. Авторизация реализована посредством токена. На текущий момент необходимо добавить обновление токена при истаечении срока действия.
- AuthorsController - предоставляет функции для получения информации о зарегистрированных авторах.
- ArticlesController - предоставляет функции для создания, редактирования и чтения статей.
- ReviewsController - предоставляет функции для создания, редактирования и чтения отзывов.
