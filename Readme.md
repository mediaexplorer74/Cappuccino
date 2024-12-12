# Cappuccino 1.0.0 - ветка xamarin-forms 
![](/Images/logo.png)

Моя попытка по-быстрому "перепилить" под UWP и винфон начатый и брошенный "замариновый" (основанный на Xamarin Forms) проект Capuccino для iOS Xamarin /Android
(а может даже и оочень лайтовый ВК-клиентик сварганить в след. году, кто знает!).
Помню, года полтора назад я находил этот проект "Каппучино", когда автор еще не держал его репозиторий на Гитхабе. И что-то поколупал его, и понял, что фиг я реализую свою задумку, так как ВК подпортил веб-авторизацию через EDGE WebView (выдает тупо черный фон), плюс я не знал рецепт этой [магии](https://gist.github.com/WamWooWam/e72e5137606f7c59ed657db6587cd5e8). 
И вот сейчас, когда более-менее вхеал в то, как обходить ограничение в использовании на Windows 10 Mobile "фич" .NET2 и Win SDK 16299, надумал сделать еще один "подход к снаряду"! :)   

## Скриншот(ы)
![Win11Lite](/Images/shot01.png)
![W10M_15254](/Images/shot02.png)

## Мои 2 цента
- В солюшн Cappuccino я добавил проект-"оснастку" Cappuccino.UWP :)
- Задал для всех проектов Xamarin Forms 4.8.0.1821, чтоб рискнуть стартануть проект на своей Люмке 950
- Чуток подрихтовал код (но пока форму авторизации не делал, тупо использую "внутренний токен")))

## Тех. моменты о моем форке 
- UWP (16299) & .NET Standard 2.0
- Xamarin Forms 4.8.0.1821
- Специальным образом организованная совместимость с W10M 15063+ (нативная компиляция, особые насторики в файлах проекта и манифеста) 

## Как добыть токен

- В совр. браузере Google Chrome войти в свой ВК. Затем открыть страницу 

https://oauth.vk.com/authorize?client_id=7317599&redirect_uri=https://oauth.vk.com/blank.html&scope=4098&response_type=token&display=mobile&revoke=1

- Подтвердить, что Вы даете доступ приложению Cappuchino доступ к своему ВК. После подтверждения адрес в строке изменится на примерно такой

https://oauth.vk.com/blank.html#access_token=ваш_токен&expires_in=86400&user_id=ваш_id

Собственно утащить токен и ид пользователя, затем вписать их в  Cappuccino.App\Cappuccino.Core.Network\Auth\ImplicitAuthentificator.cs

и скомпилировать исходники. 

## Выводы
- В результате моих манипуляций проект заработал-таки на винфоне. А мог бы и не заработать. Думаю, в будущем стоит подключать какой-нибудь логгер ошибок (да хоть самый простейший, который в log-файл в папку Images пишет exception trace. 


## Ссылки / референсы / Кредит(ы) доверия
- https://github.com/JaneySprings Никита Романов (Nikita Romanov) aka JaneySprings
- https://github.com/JaneySprings/Cappuccino (Ссыль на бывшее размещение оригинала)
- https://stackoverflow.com/questions/47421390/tab-icons-in-a-xamarin-forms-uwp-tabbedpage Как правильно "жарить" страничку со вкладками в UWP
- https://github.com/Depechie/XamarinFormsTabbedPageUWPWithIcons Страница со вкладками и иконками
- https://web.archive.org/web/20170816162053/http://depblog.weblogs.us/2017/07/12/xamarin-forms-tabbed-page-uwp-with-images/ … и архив статьи

## ..
Как есть. Чисто исследовательская тема. Сделай сам.

## .
12 декабря 2024 [m][e]