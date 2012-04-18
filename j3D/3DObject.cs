using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace j3D
{
    class Vector3 
    {
        private float _x = 0f;
        private float _y = 0f;
        private float _z = 0f;

        public float X 
        {
            get {return _x;}
            set {_x = value;}
        }

        public float Y 
        {
            get {return _y;}
            set {_y = value;}
        }

        public float Z
        {
            get {return _z;}
            set {_z = value;}
        }

    }
    class Color4 
    {
        private float _r = 0f;
        private float _g = 0f;
        private float _b = 0f;
        private float _a = 0f;

        public float R
        {
            get { return _r; }
            set { _r = value; }
        }

        public float G
        {
            get { return _g; }
            set { _g = value; }
        }

        public float B
        {
            get { return _b; }
            set { _b = value; }
        }

        public float A
        {
            get { return _a; }
            set { _a = value; }
        }

    }
    
    class ThreeDObject
    {

        private Vector3[] _vertices = null;
        private int[] _indices = null;
        private Color4[] _colors = null;
        private float[] _textureLocations = null;
        private float[] _materials = null;

        /*
         * Each object has a list of attachment points (These ar teh children)
         * a null value in Parent indicates a top level
         * Each object can have more than one child, each is a ThreeDObject
         * The ThreeDObject child must reference one of the attachment points on the parent.
         * Each object has a rotational range given on the X,Y,Z axis
         * Each object will have an a List<> of animation objects that are run in a queue (FIFO), the objects
         * should know if the animation just loops over the animation objects or does one at a time and then 
         * removes them from the queue entirely (in which case, the object stops animating)
         * Each animation class will give a starting rotation (for each axis), an ending rotation (for each axis)
         * and a time for the rotation to occur.  Also a translation start, end and duration.  When a key is
         * pressed in the main loop, it can add animation objects, clear them or even remove them, when it is
         * cleared or removed then the animation will either stop or at least not do what it was going to do.
         * Each animation can be considered like a waypoint...sort of like the StarWars Online...
         * Each object will not draw itself but will instead pass the vertices and current rotation through to
         * a master draw class
         * 
         * Need a master heartbeat, this is something that will sit in Program.cs and will simply increment
         * a 64bit integer by 1 for every tick of a hiperf timer running at 65fps.  There won't be any
         * events triggered by this, it is for lookup only.  A lock shouldn't be needed as it won't 
         * matter that much if a method grabs an old time.  The value will be used by the animation classes
         * to define a start heartbeat and an end heartbeat and a step heartbeat (each heartbeat will define
         * a certain amount of movement)
         * 
         * Object classes can share vertices, take for instance a blade of grass, they can all be defined by a 
         * master ThreeDObject and then duplicated with references to the vbo that the masterclass is using, then
         * each blade can simply be translated to the appropriate spot and rotated the appropriate amount.  This 
         * could give a nice swaying motion.
         * 
         * One thing to think about is how jointed objects will move, take the blade of grass, say it has 3 segments
         * and 2 joints, when the top segment moves x+5 then the rotation will have to be calculated and the end point
         * calculated, segment 2's attachment point will then have to move to where segment 1's end point is and so on.
         * 
         * Some form of collision detection will be needed, but it will have to be with objects around the appropriate
         * space.  Some octtree based solution will have to be devised to determine which cell the object is in and 
         * what other objects are in it.  At each frame this will need recalculating as some objects could move into
         * another cell.
         * 
         * Do simple collision, perhaps just draw a bounding box around the entire object and determine if that box intersects
         * with another objects bounding box.
         * 
         * ThreeDObject should be method agnostic and only have vertices, colors and textureID's.  This should make it so that
         * I can switch from OpenGL to DirectX.
         * 
         * */

    }
}
