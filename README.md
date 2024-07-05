# IndieInject Installer

Добро пожаловать в IndieInject Installer! Этот пакет позволяет легко устанавливать и обновлять плагин IndieInject для Unity.

## Установка

### Вариант 1: Установка через зависимости

1. Откройте файл `manifest.json` в папке `Packages` вашего Unity проекта.
2. Добавьте следующую зависимость:

    ```json
    {
        "dependencies": {
            "com.rimurudev.indieinject.installer": "https://github.com/RimuruDev/IndieInject-Installer.git"
        }
    }
    ```

3. Сохраните файл `manifest.json`. Unity автоматически скачает и установит пакет IndieInject Installer.

### Вариант 2: Установка через Unity Package Manager

1. Откройте Unity и перейдите в окно **Package Manager**: **Window** > **Package Manager**.
2. Нажмите на кнопку `+` в левом верхнем углу окна Package Manager и выберите **Add package from git URL...**.
3. Введите URL репозитория: `https://github.com/RimuruDev/IndieInject-Installer.git` и нажмите **Add**.
4. Unity автоматически скачает и установит пакет IndieInject Installer.

### Открытие окна установщика

1. После того, как пакет будет установлен, откройте Unity.
2. В верхнем меню выберите **IndieInject** > **IndieInject Package Installer**.

## Использование

### Установка плагина IndieInject

1. Откройте окно установщика, как описано выше.
2. В открывшемся окне нажмите кнопку **Install**. Установщик скачает и распакует плагин IndieInject в папку `Assets/Plugins/IndieInject`.
3. После завершения установки вы увидите сообщение о успешной установке.

### Удаление плагина IndieInject

1. Откройте окно установщика, как описано выше.
2. В открывшемся окне нажмите кнопку **Uninstall**. Установщик удалит папку `Assets/Plugins/IndieInject`.
3. После завершения удаления вы увидите сообщение о успешном удалении.

### Документация

1. Откройте окно установщика, как описано выше.
2. Нажмите кнопку **Docs**, чтобы открыть документацию плагина IndieInject на GitHub.

## Контакты

Если у вас возникли вопросы или проблемы, вы можете связаться со мной:

- **Gmail**: rimuru.dev@gmail.com
- **LinkedIn**: [Rimuru](https://www.linkedin.com/in/rimuru/)
- **GitHub**: [RimuruDev](https://github.com/RimuruDev)

## Лицензия

Этот проект лицензирован под MIT License - подробности в файле LICENSE.