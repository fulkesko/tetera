using SharpGL;
using SharpGL.SceneGraph.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace teteradefinitiva
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>OpenGL gl = args.OpenGL;

    public partial class MainWindow : Window
    {
        OpenGL gl = new OpenGL();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {

            OpenGL gl = args.OpenGL;

            // Clear The Screen And The Depth Buffer
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            // Move Left And Into The Screen
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, -6.0f);


            gl.Rotate(rotation, 0.0f, 1.0f, 0.0f);

            Teapot tp = new Teapot();
            tp.Draw(gl, 14, 1, OpenGL.GL_FILL);

            rotation += 3.0f;
        }

        float rotation = 0;

        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {

            OpenGL gl = args.OpenGL;

            gl.Enable(OpenGL.GL_DEPTH_TEST);

            //color tetera
            float[] global_ambient = new float[] { 0.5f, 0.5f, 0.5f, 1.0f };
            //posicion de la luz
            float[] light0pos = new float[] { -10f, 5.0f, 10.0f, 1.0f };
            //luz de ambiente
            float[] light0ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            //luz difusa
            float[] light0diffuse = new float[] { 0.3f, 0.3f, 0.3f, 1.0f };
            //luz espcular
            float[] light0specular = new float[] { 0.8f, 0.8f, 0.8f, 1.0f };
            //modelo ambiente
            float[] lmodel_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };

            //modelo ambiente
            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);
            //color tetera
            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, global_ambient);
            //posicion de la luz
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light0pos);
            //luz ambiente
            gl.Light(OpenGL.GL_LIGHT1, OpenGL.GL_AMBIENT, light0ambient);
            //luz difusa
            gl.Light(OpenGL.GL_LIGHT2, OpenGL.GL_DIFFUSE, light0diffuse);
            //luz especular
            gl.Light(OpenGL.GL_LIGHT3, OpenGL.GL_SPECULAR, light0specular);

            gl.Enable(OpenGL.GL_LIGHTING);
            //gl.Enable(OpenGL.GL_LIGHT_MODEL_AMBIENT);
            //gl.Enable(OpenGL.GL_LIGHT0);
            //gl.Enable(OpenGL.GL_LIGHT1);
            //gl.Enable(OpenGL.GL_LIGHT2);
            //gl.Enable(OpenGL.GL_LIGHT3);



            gl.ShadeModel(OpenGL.GL_SMOOTH);
        }


        //luz ambiental
        private void ChkLuzAmbientalGlobal_Checked(object sender, RoutedEventArgs e)
        {
            gl.Enable(OpenGL.GL_LIGHT_MODEL_AMBIENT);
        }

        //color
        private void ChkLuzAmbiente_Checked(object sender, RoutedEventArgs e)
        {
            float[] global_ambient = new float[] { 18f, 2f, 2f, -20f };
            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, global_ambient);
           

        }
        //colors
        private void ChkLuzAmbiente_Unchecked(object sender, RoutedEventArgs e)
        {
            float[] global_ambient = new float[] { 0.5f, 0.5f, 0.5f, 1.0f };
            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, global_ambient);
        }

        //luz especular on
        private void ChkLuzEspecular_Checked(object sender, RoutedEventArgs e)
        {
            gl.Enable(OpenGL.GL_LIGHT3);

        }
        //apagar luz especular off
        private void ChkLuzEspecular_Unchecked(object sender, RoutedEventArgs e)
        {
            gl.Disable(OpenGL.GL_LIGHT3);
        }

        //luz ambiental
        private void ChkLuzAmbiental_Checked(object sender, RoutedEventArgs e)
        {
            gl.Enable(OpenGL.GL_LIGHT1);
        }

        //posicion de luz on
        private void ChkPosLuz_Checked(object sender, RoutedEventArgs e)
        {
            gl.Enable(OpenGL.GL_LIGHT0);
        }

        //posicion luz off
        private void ChkPosLuz_Unchecked(object sender, RoutedEventArgs e)
        {
            gl.Disable(OpenGL.GL_LIGHT0);
        }

        //luz ambiental off
        private void ChkLuzAmbiental_Unchecked(object sender, RoutedEventArgs e)
        {
            gl.Disable(OpenGL.GL_LIGHT1);
        }

        //luz difusa off
        private void ChkLuzDifusa_Unchecked(object sender, RoutedEventArgs e)
        {
            gl.Disable(OpenGL.GL_LIGHT2);
        }

       //luz difusa on
        private void ChkLuzDifusa_Checked(object sender, RoutedEventArgs e)
        {
            gl.Enable(OpenGL.GL_LIGHT2);
        }
        //luz ambiente global off
        private void ChkLuzAmbientalGlobal_Unchecked(object sender, RoutedEventArgs e)
        {
            gl.Disable(OpenGL.GL_LIGHT_MODEL_AMBIENT);
        }
    }
}
