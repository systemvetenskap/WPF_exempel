using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Dice_3D.Models
{
    //Data för att rendera en kub. Grafiken i wpf renderas i trianglar så varje sida sida behöver 2 trianglar för att skapa en kvadrat och 6 kvadrater för en kub.
    public static class CubeRenderData
    {
        //Alla hörnpunkter i en 3D kub (x,y,z).
        public static List<Point3D> Points3D { get; } = new List<Point3D>() { new Point3D(0.5, -0.5, 0.5), new Point3D(0.5, -0.5, -0.5), new Point3D(0.5, 0.5, -0.5), new Point3D(0.5, 0.5, 0.5), new Point3D(-0.5, -0.5, 0.5), new Point3D(-0.5, -0.5, -0.5), new Point3D(-0.5, 0.5, -0.5), new Point3D(-0.5, 0.5, 0.5) };

        //Array som säger vilka punkter som ska kopplas ihop på varje sida i kuben (2 trianglar per "fack").
        public static int[,] PointSchemeCube { get; } = { { 4, 0, 3, 4, 3, 7 }, { 0, 1, 2, 0, 2, 3 }, {7, 3, 2, 7, 2, 6 }, {5, 1, 0, 5, 0, 4 }, {5, 4, 7, 5, 7, 6 } ,{ 6, 2, 1, 5, 6, 1 } };
        
        //Bestämmer vad som är normalen (framåt) för varje sida.
        public static  List<Vector3D> Normals { get; } = new List<Vector3D>() {  new Vector3D(0, 0, 1), new Vector3D(1, 0, 0 ), new Vector3D( 0, 1, 0 ),new Vector3D(0, -1, 0 ), new Vector3D( -1, 0, 0 ),new Vector3D(0, 0, -1 ) };
        
        //Bestämmer hur texturen(materialet) ska ligga på sidorna.
        public static PointCollection TextureCoordinates { get; } = new PointCollection() { new Point(1, 0), new Point(1, 1), new Point(0, 1), new Point(0, 1), new Point(1, 0), new Point(0, 0) };
    }
}
