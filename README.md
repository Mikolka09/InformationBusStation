# InformationBusStation (WinForms, C#)
Создать MDI-приложение с использованием стандартных диалоговых окон SaveFileDialog, OpenFileDialog, позволяющее:
- сохранять вводимые данные в текстовом файле,
- просматривать, корректировать, удалять записи из файла;
- выводить результаты работы программы на экран и сохранять в другой текстовый файл;
- Иметь возможность делать выборку данных по различным критериям;
- Переносить данные из одной формы в другую.
Добавить пункты меню для сохранения объектов в файл и загрузки. При сохранении использовать стандартные диалоговые окна и механизм сериализации. В класс добавить поле
дата создания объекта. Это поле не сериализовать, а при десериализации заново устанавливать по системной дате.
В справочной автовокзала хранится расписание движения автобусов. Для каждого рейса указаны:
- номер автобуса;
- тип автобуса;
- пункт назначения;
- дата отправления (дд/мм/гггг);
- время отправления;
- дата прибытия (дд/мм/гггг);
- время прибытия.
Вывести информацию о рейсах, которыми можно воспользоваться для прибытия в пункт назначения (вводится с клавиатуры) раньше заданного времени (вводится с клавиатуры).

Create an MDI application using standard dialog boxes SaveFileDialog, OpenFileDialog, allowing you to:
- save the entered data in a text file,
- view, correct, delete records from the file;
- display the results of the program on the screen and save to another text file;
- Be able to sample data according to various criteria;
- Transfer data from one form to another.
Add menu items to save objects to file and load. When saving, use standard dialog boxes and the serialization mechanism. Add a field to the class
the date the object was created. Do not serialize this field, but re-set it to the system date during deserialization.
The bus station information desk stores the bus schedule. For each flight there are:
- bus number;
- the type of bus;
- destination;
- departure date (dd/mm/yyyy);
- departure time;
- arrival date (dd/mm/yyyy);
- Arrival time.
Display information about flights that can be used to arrive at the destination (entered from the keyboard) before the specified time (entered from the keyboard).
