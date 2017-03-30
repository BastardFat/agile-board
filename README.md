# agile-board
## Тестовое задание

Использовано:
- ASP.NET MVC с .NET Framework 4.5.2
- Postgresql база данных
- Npgsql и EntityFramework
- Web Api 2
- Bootstrap, чтобы шустренько сверстать фронт
- CommonMark.NET чтобы прикрутить такую вкусность как Markdown
- jQuery разумеется
- Newtonsoft.Json в коробке (так что я о нем и не парился)

Вроде все вспомнил

**Итак, что сделано:**
1. Авторизация через куки
2. Регистрация
3. Возможность сменить пароль (который кстати в базе в виде хеша sha1 хранится)
4. У каждого пользователя своя доска
5. Три стадии задачи на доске:

  ![Первая картинка](https://raw.githubusercontent.com/BastardFat/agile-board/master/BastardFat.AgileBoard.Site/img/1.png)
  
6. Возможность сворачивать описание:

  ![Вторая картинка](https://raw.githubusercontent.com/BastardFat/agile-board/master/BastardFat.AgileBoard.Site/img/2.png)
  
7. В описаниях поддерживается маркдаун:

  ![Третья картинка](https://raw.githubusercontent.com/BastardFat/agile-board/master/BastardFat.AgileBoard.Site/img/3.png)
  ![Четвертая картинка](https://raw.githubusercontent.com/BastardFat/agile-board/master/BastardFat.AgileBoard.Site/img/4.png)
  
8. Архивация выполненых задач:

  ![Пятая картинка](https://raw.githubusercontent.com/BastardFat/agile-board/master/BastardFat.AgileBoard.Site/img/5.png)
  ![Шестая картинка](https://raw.githubusercontent.com/BastardFat/agile-board/master/BastardFat.AgileBoard.Site/img/6.png)
  
9. Есть админ с минимальными возможностями АДМИНИСТРИРОВАНИЯ (громко сказано, на самом деле он может только удалять пользователей):

  ![Седьмая картинка](https://raw.githubusercontent.com/BastardFat/agile-board/master/BastardFat.AgileBoard.Site/img/7.png)
  ![Восьмая картинка](https://raw.githubusercontent.com/BastardFat/agile-board/master/BastardFat.AgileBoard.Site/img/8.png)
  
 Вроде ничего не забыл. Хочется спать. Всего доброго
 
 Господи, перечитывал и заметил, что не поменял "Имя приложения" на Layout'е. Сейчас исправлю
