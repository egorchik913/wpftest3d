using HelixToolkit.Wpf;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace wpftest3d
{

    public partial class MainWindow : Window
    {
        Model3D pin;

        Model3D model1;
        Model3D model1Dark;

        Model3D model2;
        Model3D model2Dark;

        Model3D model3;
        Model3D model3Dark;

        Model3D model4;
        Model3D model5;
        Model3D model6;
        Model3D model7;
        Model3D model8;
        Model3D model9;
        Model3D model10;

        public MainWindow()
        {
            InitializeComponent();
            ModelImporter importer = new ModelImporter();

            //камера
            OrthographicCamera camera = new OrthographicCamera();
            camera.Position = new Point3D(0, 2, 5);
            camera.LookDirection = new Vector3D(0, -2, -5);
            camera.Width = 1.5;
            viewport.Camera = camera;

            //МОДЕЛИ
            //pin
            pin = importer.Load("D:/3D/TATNEFT/MapOtdelno/pin.obj");
            ModelUIElement3D UIpin = new ModelUIElement3D();
            UIpin.Model = pin;

            UIpin.Transform = new TranslateTransform3D(0, 0.02, 0);

            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0.02;
            animation.To = 0.03;
            animation.AutoReverse = true;
            animation.Duration = TimeSpan.FromSeconds(1);
            animation.RepeatBehavior = RepeatBehavior.Forever;

            //Функции
            void UI_MouseEnter(ModelUIElement3D modelUIElement, ModelUIElement3D modelUIElementDark)
            {
                viewport.Children.Remove(modelUIElement);
                viewport.Children.Add(modelUIElementDark);
            };

            void UI_MouseLeave(ModelUIElement3D modelUIElement, ModelUIElement3D modelUIElementDark)
            {
                viewport.Children.Remove(modelUIElementDark);
                viewport.Children.Add(modelUIElement);
            };

            void UI_MouseDown(ModelUIElement3D modelUIElement, ModelUIElement3D modelUIElementDark)
            {
                
            };

            bool[] isFunctionEnabled = { true, true, true, true, true, true, true, true, true, true };


            //Альметьевск
            model1 = importer.Load("D:/3D/TATNEFT/MapOtdelno/almet.obj");
            ModelUIElement3D UImodel1 = new ModelUIElement3D();
            UImodel1.Model = model1;
            viewport.Children.Add(UImodel1);
            //АльметьевскDark
            model1Dark = importer.Load("D:/3D/TATNEFT/MapOtdelnoDark/almetDark.obj");
            ModelUIElement3D UImodel1Dark = new ModelUIElement3D();
            UImodel1Dark.Model = model1Dark;
            UImodel1Dark.Transform = new TranslateTransform3D(0, 0.01, 0);

            UImodel1.MouseEnter += (sender, e) =>
            {
                UI_MouseEnter(UImodel1, UImodel1Dark);
                NameNGDY.Text = "НГДУ АльметНефть";
            };

            UImodel1Dark.MouseLeave += (sender, e) =>
            {
                if (isFunctionEnabled[0] == true)
                {
                    UI_MouseLeave(UImodel1, UImodel1Dark);
                    NameNGDY.Text = null;
                }
            };

            UImodel1Dark.MouseDown += (sender, e) =>
            {
                switch (isFunctionEnabled[0])
                {
                    case true:
                        isFunctionEnabled[0] = !isFunctionEnabled[0];
                        //if (NameNGDY.Text != null)
                        //{
                        //    NameNGDY.Text += ", НГДУ АльметНефть";
                        //}
                        break;
                    case false:
                        isFunctionEnabled[0] = !isFunctionEnabled[0];
                        break;
                }
            };

            //Азнакаево
            model2 = importer.Load("D:/3D/TATNEFT/MapOtdelno/aznakaev.obj");
            ModelUIElement3D UImodel2 = new ModelUIElement3D();
            UImodel2.Model = model2;
            viewport.Children.Add(UImodel2);
            //АзнакаевоDark
            model2Dark = importer.Load("D:/3D/TATNEFT/MapOtdelnoDark/aznakaevDark.obj");
            ModelUIElement3D UImodel2Dark = new ModelUIElement3D();
            UImodel2Dark.Model = model2Dark;
            UImodel2Dark.Transform = new TranslateTransform3D(0, 0.01, 0);

            UImodel2.MouseEnter += (sender, e) =>
            {
                UI_MouseEnter(UImodel2, UImodel2Dark);
                viewport.Children.Add(UIpin);
                UIpin.Transform.BeginAnimation(TranslateTransform3D.OffsetYProperty, animation);
                NameNGDY.Text = "НГДУ АзнакаевНефть";
            };

            UImodel2Dark.MouseLeave += (sender, e) =>
            {
                if (isFunctionEnabled[1] == true)
                {
                    UI_MouseLeave(UImodel2, UImodel2Dark);
                    viewport.Children.Remove(UIpin);
                    NameNGDY.Text = null;
                }
            };

            UImodel2Dark.MouseDown += (sender, e) =>
            {
                switch (isFunctionEnabled[1])
                {
                    case true:
                        isFunctionEnabled[1] = !isFunctionEnabled[1];
                        break;
                    case false:
                        isFunctionEnabled[1] = !isFunctionEnabled[1];
                        break;
                }
            };

            //Бавлы
            model3 = importer.Load("D:/3D/TATNEFT/MapOtdelno/bavlinsk.obj");
            ModelUIElement3D UImodel3 = new ModelUIElement3D();
            UImodel3.Model = model3;
            viewport.Children.Add(UImodel3);
            //БавлыDark
            model3Dark = importer.Load("D:/3D/TATNEFT/MapOtdelnoDark/bavlinskDark.obj");
            ModelUIElement3D UImodel3Dark = new ModelUIElement3D();
            UImodel3Dark.Model = model3Dark;
            UImodel3Dark.Transform = new TranslateTransform3D(0, 0.01, 0);

            UImodel3.MouseEnter += (sender, e) =>
            {
                UI_MouseEnter(UImodel3, UImodel3Dark);
                UIpin.Transform.BeginAnimation(TranslateTransform3D.OffsetYProperty, animation);
                NameNGDY.Text = "НГДУ БавлыНефть";
            };

            UImodel3Dark.MouseLeave += (sender, e) =>
            {
                if (isFunctionEnabled[2] == true)
                {
                    UI_MouseLeave(UImodel3, UImodel3Dark);
                    NameNGDY.Text = null;
                }
            };

            UImodel3Dark.MouseDown += (sender, e) =>
            {
                switch (isFunctionEnabled[2])
                {
                    case true:
                        isFunctionEnabled[2] = !isFunctionEnabled[2];
                        break;
                    case false:
                        isFunctionEnabled[2] = !isFunctionEnabled[2];
                        break;
                }
            };

            //Джалиль
            model4 = importer.Load("D:/3D/TATNEFT/MapOtdelno/djalil.obj");
            ModelUIElement3D UImodel4 = new ModelUIElement3D();
            UImodel4.Model = model4;
            viewport.Children.Add(UImodel4);

            //Елхов
            model5 = importer.Load("D:/3D/TATNEFT/MapOtdelno/elhov.obj");
            ModelUIElement3D UImodel5 = new ModelUIElement3D();
            UImodel5.Model = model5;
            viewport.Children.Add(UImodel5);

            //Призрак
            model6 = importer.Load("D:/3D/TATNEFT/MapOtdelno/ghost.obj");
            ModelUIElement3D UImodel6 = new ModelUIElement3D();
            UImodel6.Model = model6;
            viewport.Children.Add(UImodel6);

            //Лениногорск
            model7 = importer.Load("D:/3D/TATNEFT/MapOtdelno/lensk.obj");
            ModelUIElement3D UImodel7 = new ModelUIElement3D();
            UImodel7.Model = model7;
            viewport.Children.Add(UImodel7);

            //Нурлат
            model8 = importer.Load("D:/3D/TATNEFT/MapOtdelno/nurlat.obj");
            ModelUIElement3D UImodel8 = new ModelUIElement3D();
            UImodel8.Model = model8;
            viewport.Children.Add(UImodel8);

            //Прикам
            model9 = importer.Load("D:/3D/TATNEFT/MapOtdelno/prikam.obj");
            ModelUIElement3D UImodel9 = new ModelUIElement3D();
            UImodel9.Model = model9;
            viewport.Children.Add(UImodel9);

            //Ямаш
            model10 = importer.Load("D:/3D/TATNEFT/MapOtdelno/yamash.obj");
            ModelUIElement3D UImodel10 = new ModelUIElement3D();
            UImodel10.Model = model10;
            viewport.Children.Add(UImodel10);
        }
    }
}


