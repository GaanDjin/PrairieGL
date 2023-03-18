using TestPrairieGL.VulkanTutorials;
using TestPrairieGL.OpenGLTutorials;

//_00_base_code.Main();
//_01_instance_creation.Main();
//_02_validation_layers.Main();
//_03_physical_device_selection.Main();
//_04_logical_device.Main();

Console.WriteLine("Prairie GL Tests.");

string promptValue;
do
{

    Console.WriteLine("Please enter the number of OpenGL Tutorial to run.");
    Console.WriteLine("Tutorial 01. Open a Window! [01]");
    Console.WriteLine("Tutorial 02. Red Triangle [02]");
    Console.WriteLine("Tutorial 03. Matrices [03]");
    Console.WriteLine("Tutorial 04. Colored Cube [04]");
    Console.WriteLine("Tutorial 05. Textured Cube [05]");
    Console.WriteLine("Tutorial 06. Keyboard and Mouse [06]");
    Console.WriteLine("Tutorial 07. Keyboard and Mouse [07]");
    Console.WriteLine("Tutorial 08. Basic Shading [08]");
    Console.WriteLine("Tutorial 09. VBO Indexing [09]");
    Console.WriteLine("Tutorial 10. Transparency [10]");
    Console.WriteLine("Tutorial 11. 2d Fonts [11]");
    Console.WriteLine("Tutorial 12. Extensions & Debug Callbacks [12]");
    Console.WriteLine("Tutorial 13. Normal Mapping [13]");
    Console.WriteLine("Tutorial 14. Render To Texture [14]");
    Console.WriteLine("Tutorial 18. Billboards  [15]");
    Console.WriteLine("Tutorial 18. Particles [16]");
    Console.WriteLine("Misc. Custom Object picking [17]");
    Console.WriteLine("Quit [q]");

    promptValue = Console.ReadLine();
    int promptNum = 0;

    int.TryParse(promptValue, out promptNum);

    switch (promptNum)
    {
        case 1:
            ///Tutorial 01. Open a window!
            Tutorial01.main();
            break;
        case 2:
            ///Tutorial 02. Red Triangle
            Tutorial02.main();
            break;
        case 3:
            ///Tutorial 03. matrices
            Tutorial03.main();
            break;
        case 4:
            ///Tutorial 04. colored_cube
            Tutorial04.main();
            break;
        case 5:
            ///Tutorial 05. Textured Cube
            Tutorial05.main();
            break;
        case 6:
            ///Tutorial 06. keyboard and Mouse
            Tutorial06.main();
            break;
        case 7:
            ///Tutorial 07. keyboard and Mouse
            Tutorial07.main();
            break;
        case 8:
            ///Tutorial 08. basic shading
            Tutorial08.main();
            break;
        case 9:
            ///Tutorial 09. vbo indexing
            Tutorial09.main();
            break;
        case 10:
            ///Tutorial 10. Transparency
            Tutorial10.main();
            break;
        case 11:
            ///Tutorial 11. 2d fonts
            Tutorial11.main();
            break;
        case 12:
            ///Tutorial 12. Extensions & debug callbacks
            Tutorial12.main();
            break;
        case 13:
            ///Tutorial 13. Normal Mapping
            Tutorial13.main();
            break;
        case 14:
            ///Tutorial 14. Render To Texture
            Tutorial14.main();
            break;
        case 15:
            ///Tutorial 18. Billboards & Particles
            Tutorial18Billboards.main();
            break;
        case 16:
            Tutorial18Particles.main();
            break;
        case 17:
            Misc05PickingCustom.main();
            break;
        case 18:
            break;
    }
}
while (promptValue != null
    && !promptValue.Equals("q")
    && !promptValue.Equals("quit"));

