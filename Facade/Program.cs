using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryDirectX libraryDirectX = new LibraryDirectX();
            GameRun gameRun = new GameRun();
            Downloader downloader = new Downloader();
            
            

            SteamFacade ide = new SteamFacade(libraryDirectX, downloader, gameRun);

            Gamer gamer = new Gamer();
            gamer.LaunchApplication(ide);

            Console.Read();
        }
    }
    // проверка библиотеки ДиректХ
    class LibraryDirectX
    {
        public void CheckLibrary()
        {
            Console.WriteLine("Проверка необходимых файлов библиотек для запуска игры");
        }
        public void Complete()
        {
            Console.WriteLine("Проверка завершена");
        }
    }
    class Downloader
    {
        public void Download()
        {
            Console.WriteLine("Загрузить игру");
        }
    }
    class GameRun
    {
        public void Execute()
        {
            Console.WriteLine("Запуск игры");
        }
        public void Finish()
        {
            Console.WriteLine("Завершение работы игры");
        }
    }

    //фасад предоставляет интерфейс клиенту для работы с компонентами
    class SteamFacade
    {
        LibraryDirectX libraryDirectX;
        Downloader downloader;
        GameRun gameRun;
        public SteamFacade(LibraryDirectX ld, Downloader download, GameRun gr)
        {
            this.libraryDirectX = ld;
            this.downloader = download;
            this.gameRun = gr;
        }
        public void Start()
        {
            libraryDirectX.CheckLibrary();
            libraryDirectX.Complete();
            downloader.Download();
            gameRun.Execute();
        }
        public void Stop()
        {
            gameRun.Finish();
        }
    }

    class Gamer
    {
        public void LaunchApplication(SteamFacade facade)
        {
            facade.Start();
            facade.Stop();
        }
    }
}
