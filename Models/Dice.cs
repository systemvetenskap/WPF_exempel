using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using static Dice_3D.Models.CubeRenderData; //Använder vår statiska data i CubeRenderData

namespace Dice_3D.Models
{
    public class Dice
    {
        //Skapar en tärning direkt vi instansierar klassen via konstruktorn
        public Dice()
        {
            GenerateDice();
        }

        //Vår grupp av 6 sidor som utgör kuben. I grupp så att vi kan annimera den som ett föremål. 
        public Model3DGroup DiceModel { get; set; } = new Model3DGroup();

        //Skapar en tärning och sparar den i property DiceModel(Model3DGroup).
        public void GenerateDice()
        {
            //Skapar en sida i taget
            for (int diceSideNumber = 0 ; diceSideNumber < 6; diceSideNumber++)
            {
                MeshGeometry3D mesh = new MeshGeometry3D();
                for (int pointNumber = 0; pointNumber < 6; pointNumber++)
                {
                    mesh.Positions.Add(Points3D[PointSchemeCube[diceSideNumber, pointNumber]]);
                    mesh.TriangleIndices.Add(pointNumber);
                    mesh.Normals.Add(Normals[diceSideNumber]);
                }

                // Lägger till våra koordinater för texturen(materialet). Tar sidnumret då sista sidan inte vill lira och behöver ett undantag. 
                GenerateTextureCoords(mesh, diceSideNumber);

                //Skapar ett nytt material med bilden som vi vill ha. Då detta ska vara olika på varje sida så ändrar vi filnamnet som ska hämtas dynamiskt med loopen.
                DiffuseMaterial material = new DiffuseMaterial(new ImageBrush(new BitmapImage(new Uri($@"./Assets/Images/{diceSideNumber + 1}.png", UriKind.Relative))));
                
                // Tar vår mesh och vårt material och skapar en geometrisk figur (ett plan).
                GeometryModel3D diceSidePlane = new GeometryModel3D(mesh, material);

                //Lägger till sidan som ett barn i vår Model3DGroup.
                DiceModel.Children.Add(diceSidePlane);
            }

                
        }
        private void GenerateTextureCoords(MeshGeometry3D mesh, int diceSideNumber)
        {
            if (diceSideNumber != 5)
            {
                mesh.TextureCoordinates = TextureCoordinates;
            }
            else
            {
                mesh.TextureCoordinates.Add(new Point(1, 0));
                mesh.TextureCoordinates.Add(new Point(1, 1));
                mesh.TextureCoordinates.Add(new Point(0, 1));
                mesh.TextureCoordinates.Add(new Point(0, 1));
                mesh.TextureCoordinates.Add(new Point(1, 1));
                mesh.TextureCoordinates.Add(new Point(0, 0));
            }
        }
    }
}
