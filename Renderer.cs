using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using GlmNet;
using System.IO;
using Graphics._3D_Models;
namespace Graphics
{
    class Renderer
    {
        Shader sh;
        int transID;
        int viewID;
        int projID;


        int EyePositionID;
        int AmbientLightID;
        int DataID;

        mat4 ProjectionMatrix;
        mat4 ViewMatrix;

        public float Speed = 0.001f;

        uint vertexBufferID;

        public Camera cam;

        public md2LOL m; //el zombie 
        public md2LOL enemy2; // zombie 
       

       // int modelID;
        public Model3D building;
        public Model3D tree;
        public Model3D spider;
        public Model3D jeep;
        public Model3D house;

        Texture tex1; //ground tex

        mat4 modelmatrix;//for zombie
      //  mat4 modelmatrix2;


        uint SkyboxBufferID;
        uint cubeCoordID;

        //Triangle Buffers
        uint vertexBufferID2;
        uint TriangleCoordID;
        //triangle tex
        Texture tex;


        //Triangle2 Buffers
        uint vertexBuffer2ID2;
        uint TriangleCoord2ID;

        //triangle2 tex
        Texture textri2;

        //skybox tex
        Texture Downtex;
        Texture Uptex;
        Texture Lefttex;
        Texture Righttex;
        Texture Backtex;
        Texture Fronttex;


        public void Initialize()
        {

            string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            sh = new Shader(projectPath + "\\Shaders\\SimpleVertexShader.vertexshader", projectPath + "\\Shaders\\SimpleFragmentShader.fragmentshader");

            //tex1 = new Texture(projectPath + "\\Textures\\grass_mix_d.jpg", 2);
            tex1 = new Texture(projectPath + "\\Textures\\ground_cracks2v_d.jpg", 2);

            tex = new Texture(projectPath + "\\Textures\\crate.jpg", 3);
            textri2 = new Texture(projectPath + "\\Textures\\crate.jpg", 4);


             //m = new md2LOL(projectPath + "\\ModelFiles\\animated\\md2LOL\\fiora.md2"); //bytl3 ghreb!!!!!!!!!!
            m = new md2LOL(projectPath + "\\ModelFiles\\zombie.md2");
            m.StartAnimation(animType_LOL.STAND);
            m.rotationMatrix = glm.rotate((float)((-90.0f / 180) * Math.PI), new vec3(1, 0, 0));
            m.scaleMatrix = glm.scale(new mat4(1), new vec3(0.8f, 0.8f, 0.8f));
            m.TranslationMatrix = glm.translate(new mat4(1), new vec3(15, 1, 20));

            // enemy2 = new md2LOL(projectPath + "\\ModelFiles\\animated\\md2LOL\\zombie1.md2");
            enemy2 = new md2LOL(projectPath + "\\ModelFiles\\zombie.md2");
            enemy2.StartAnimation(animType_LOL.STAND);
            enemy2.rotationMatrix = glm.rotate((float)((-90.0f / 180) * Math.PI), new vec3(1, 0, 0));
            enemy2.scaleMatrix = glm.scale(new mat4(1), new vec3(0.8f, 0.8f, 0.8f));
            enemy2.TranslationMatrix = glm.translate(new mat4(1), new vec3(30, 1, 20));

            //building PROBLEM HERE 
                 building = new Model3D();
                 building.LoadFile(projectPath + "\\ModelFiles\\static\\building", 5, "Building 02.obj");
                 building.scalematrix = glm.scale(new mat4(1), new vec3(20,20,30));
                 building.transmatrix = glm.translate(new mat4(1), new vec3(200,40,-300)); 

            //tree
                 tree = new Model3D();
                 tree.LoadFile(projectPath + "\\ModelFiles\\static\\tree", 6, "Tree.obj");
                 tree.scalematrix = glm.scale(new mat4(1), new vec3(5f,10f,5f));
                 tree.transmatrix = glm.translate(new mat4(1), new vec3(-70, 10, 1));

            //spider 
            spider = new Model3D();
            spider.LoadFile(projectPath + "\\ModelFiles\\static\\spider", 7, "spider.obj");
            spider.scalematrix = glm.scale(new mat4(1), new vec3(0.099f,0.099f,0.099f));
            spider.transmatrix = glm.translate(new mat4(1), new vec3(-70, 2, 1));

            //jeep
            jeep = new Model3D();
            jeep.LoadFile(projectPath + "\\ModelFiles\\static\\car", 8, "dpv.obj");
            jeep.scalematrix = glm.scale(new mat4(1), new vec3(0.1f, 0.1f, 0.1f));
            jeep.transmatrix = glm.translate(new mat4(1), new vec3(-50,5,1));
            jeep.rotmatrix = glm.rotate((float)((1 / 180) * Math.PI), new vec3(1, 0, 0));

            //house
            house = new Model3D();
            house.LoadFile(projectPath + "\\ModelFiles\\static\\house", 9, "house.obj");
            house.scalematrix = glm.scale(new mat4(1), new vec3(9,9,9));
            house.transmatrix = glm.translate(new mat4(1), new vec3(-60, 10,-45));


            // skybox 
            Downtex = new Texture(projectPath + "\\Textures\\nottingham_dn.jpg", 2); //ground
            Uptex = new Texture(projectPath + "\\Textures\\nottingham_up.jpg", 3); //up
            Fronttex = new Texture(projectPath + "\\Textures\\nottingham_ft.jpg", 4);//front
            Righttex = new Texture(projectPath + "\\Textures\\nottingham_rt.jpg", 5); //right
            Backtex = new Texture(projectPath + "\\Textures\\nottingham_bk.jpg", 6); ///back
            Lefttex = new Texture(projectPath + "\\Textures\\nottingham_lf.jpg", 7); //left



            //define normal for each vertex
            float[] ground = {
                -10.0f, 0.0f, 10.0f,
                 0,0,1,
                 0,1,
                 0,1,0,

                 10.0f, 0.0f, -10.0f,
                 0,0,1,
                 1,0,
                 0,1,0,


                 -10.0f, 0.0f, -10.0f,
                 0,0,1,
                 0,0,
                 0,1,0,

                 10.0f, 0.0f, 10.0f,
                 0,0,1,
                 1,1,
                 0,1,0,

                -10.0f, 0.0f, 10.0f,
                 0,0,1,
                 0,1,
                 0,1,0,

                 10.0f, 0.0f, -10.0f,
                 0,0,1,
                 1,0,
                 0,1,0,
            };
            vertexBufferID = GPU.GenerateBuffer(ground);

            //skybox

            Gl.glClearColor(1.0f, 1.0f, 1.0f, 1);

            float[] myCube = {
                //ground
               -10.0f, -1.0f, -10.0f, //0
                1,0,0,
                0,1,0,

                -10.0f, -1.0f, 10.0f,//1
                1,0,0,
                0,1,0,

                10.0f, -1.0f, 10.0f,//2
                1,0,0,
                0,1,0,

                10.0f, -1.0f, -10.0f,//3 
                1,0,0,
                0,1,0,
                         
                //roof
                -10.0f, 9.0f, -10.0f,//4
                1,0,0,
                0,1,0,

                -10.0f, 9.0f, 10.0f,//10
                1,0,0,
                0,1,0,

                10.0f, 9.0f, 10.0f,//6
                1,0,0,
                0,1,0,

                10.0f, 9.0f, -10.0f,//7
                1,0,0,
                0,1,0,
          
                 //back
                -10.0f, -1.0f, -10.0f,//8
                1,0,0,
                0,1,0,

                -10.0f, 9.0f, -10.0f,//10
                1,0,0,
                0,1,0, //normal

                10.0f, 9.0f, -10.0f,//9
                1,0,0,
                0,1,0,

                10.0f, -1.0f, -10.0f,//11
                1,0,0,
                0,1,0,
                                     
                //right
                10.0f, -1.0f, -10.0f,//12
                1,0,0,
                0,1,0,

                10.0f, 9.0f, -10.0f,//14
                1,0,0,
                0,1,0,

                10.0f, 9.0f, 10.0f,//13
                1,0,0,
                0,1,0,

                10.0f, -1.0f, 10.0f,//110
                1,0,0,
                0,1,0,
                    
               //front
                -10.0f, -1.0f, 10.0f,//8
                1,0,0,
                0,1,0,

                10.0f, -1.0f, 10.0f,//11
                1,0,0,
                0,1,0,

                10.0f, 9.0f, 10.0f,//10
                1,0,0,
                0,1,0,

                -10.0f, 9.0f, 10.0f,//9
                1,0,0,
                0,1,0, 

                //left
                -10.0f, -1.0f, -10.0f, //20
                1,0,0,
                0,1,0,

               -10.0f, -1.0f, 10.0f,//23
                1,0,0,
                0,1,0,

                -10.0f, 9.0f, 10.0f,//21
                1,0,0,
                0,1,0,

                -10.0f, 9.0f, -10.0f,//22
                1,0,0,
                0,1,0,
            };


            float[] CubeCoord =
            {        
             //down
                
                1,0,
                0,0,
                0,1,
                1,1,
                /////22222   up
              
              0,0,
              1,0,
              1,1,
              0,1,
                /////333333  BACK
                
              0,1,
              0,0,
              1,0,
              1,1,

                /////444444  right  
               0,1,
               0,0,
               1,0,
               1,1,

                /////555555 front
                
            
                 1,1,
                0,1,
                0,0,
                1,0,


                /////66666   left
                1,1,
                0,1,
                0,0,
                1,0,

            };



            SkyboxBufferID = GPU.GenerateBuffer(myCube);
            cubeCoordID = GPU.GenerateBuffer(CubeCoord);

            //triangle
            float[] TrianleCoord =
            {
                0,0,
                1,1,
                0,1,
            };

            float[] triangle = {
                -1.0f, -1.0f, 0.0f,
                 0,0,0,
                 1.0f, -1.0f, 0.0f,
                 0,0,0,
                 0.0f,  1.0f, 0.0f,
                 0,0,0,
            };

            vertexBufferID2 = GPU.GenerateBuffer(triangle);
            TriangleCoordID = GPU.GenerateBuffer(TrianleCoord);

            //2nd triangle
            //triangle
            float[] TrianleCoord2 =
         {
                0,0,
                1,1,
                0,1,
            };

            float[] triangle2 = {
                -1.0f, -1.0f, 0.0f,
                 0,0,0,
                 1.0f, -1.0f, 0.0f,
                 0,0,0,
                 0.0f,  1.0f, 0.0f,
                 0,0,0,
            };

            vertexBuffer2ID2 = GPU.GenerateBuffer(triangle2);
            TriangleCoord2ID = GPU.GenerateBuffer(TrianleCoord2);


            Gl.glClearColor(0, 0, 0.4f, 1);

            cam = new Camera();
            cam.Reset(0, 34, 100, 0, 0, 0, 0, 1, 0);

            ProjectionMatrix = cam.GetProjectionMatrix();
            ViewMatrix = cam.GetViewMatrix();

            transID = Gl.glGetUniformLocation(sh.ID, "trans"); //7ala m7l l model kman fl vertex shader 
            projID = Gl.glGetUniformLocation(sh.ID, "projection");
            viewID = Gl.glGetUniformLocation(sh.ID, "view");
            //modelID = Gl.glGetUniformLocation(sh.ID, "model");

            modelmatrix = glm.scale(new mat4(1), new vec3(50, 50, 50))*glm.translate(new mat4(1), new vec3(1,1,1)); //here! zombies
           // modelmatrix2 = glm.scale(new mat4(1), new vec3(15,15,15)) * glm.translate(new mat4(1), new vec3(80, 100, -100)); //wooden triangle1

            sh.UseShader();

            //get location of specular and attenuation then send their values
            //get location of light position and send its value
            //setup the ambient light component.
            //setup the eye position.

            camposID = Gl.glGetUniformLocation(sh.ID, "campos");

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glDepthFunc(Gl.GL_LESS);
        }
        int camposID;
        public void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            sh.UseShader();

            Gl.glUniformMatrix4fv(projID, 1, Gl.GL_FALSE, ProjectionMatrix.to_array());
            Gl.glUniformMatrix4fv(viewID, 1, Gl.GL_FALSE, ViewMatrix.to_array());

            //send the value of camera position (eye position)

           // m.TranslationMatrix = glm.translate(new mat4(1), new vec3(100, 0, 0)); //zombie
            m.Draw(transID);

           // enemy2.TranslationMatrix = glm.translate(new mat4(1), new vec3(50, 0, 0)); //zombie
            enemy2.Draw(transID);

              //ground draw
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, vertexBufferID);
            Gl.glUniformMatrix4fv(transID, 1, Gl.GL_FALSE, modelmatrix.to_array());
            Gl.glEnableVertexAttribArray(0);
            Gl.glVertexAttribPointer(0, 3, Gl.GL_FLOAT, Gl.GL_FALSE, 11 * sizeof(float), IntPtr.Zero);
            Gl.glEnableVertexAttribArray(1);
            Gl.glVertexAttribPointer(1, 3, Gl.GL_FLOAT, Gl.GL_FALSE, 11 * sizeof(float), (IntPtr)(3 * sizeof(float)));
            Gl.glEnableVertexAttribArray(2);
            Gl.glVertexAttribPointer(2, 2, Gl.GL_FLOAT, Gl.GL_FALSE, 11 * sizeof(float), (IntPtr)(6 * sizeof(float)));
            //enable another vertex attribute for normals
            //describe the attribute and recompute the stride for all attributes
            Gl.glEnableVertexAttribArray(3);
            Gl.glVertexAttribPointer(3, 3, Gl.GL_FLOAT, Gl.GL_FALSE, 11 * sizeof(float), (IntPtr)(8 * sizeof(float)));
            tex1.Bind();
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 0, 6);

            ///////////////////////////////skybox draw & textures/////////////////////////////////////////////
            GPU.BindBuffer(SkyboxBufferID);
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, SkyboxBufferID);
            Gl.glEnableVertexAttribArray(0);
            Gl.glVertexAttribPointer(0, 3, Gl.GL_FLOAT, Gl.GL_FALSE, 9 * sizeof(float), IntPtr.Zero);
            Gl.glEnableVertexAttribArray(1);
            Gl.glVertexAttribPointer(1, 3, Gl.GL_FLOAT, Gl.GL_FALSE, 9 * sizeof(float), (IntPtr)(3 * sizeof(float)));
            Gl.glEnableVertexAttribArray(2);
            Gl.glVertexAttribPointer(2, 3, Gl.GL_FLOAT, Gl.GL_FALSE, 9 * sizeof(float), (IntPtr)(6 * sizeof(float)));
            //cube coord 
            GPU.BindBuffer(cubeCoordID);
            Gl.glEnableVertexAttribArray(2);
            Gl.glVertexAttribPointer(2, 2, Gl.GL_FLOAT, Gl.GL_FALSE, 0, (IntPtr)(0));

            Downtex.Bind();
            //Gl.glDrawArrays(Gl.GL_TRIANGLES,0,36);
            Gl.glDrawArrays(Gl.GL_QUADS, 0, 4);

            Uptex.Bind();
            Gl.glDrawArrays(Gl.GL_QUADS, 4, 4);

            Backtex.Bind();
            Gl.glDrawArrays(Gl.GL_QUADS, 8, 4);

            Righttex.Bind();
            Gl.glDrawArrays(Gl.GL_QUADS, 12, 4);

            Fronttex.Bind();
            Gl.glDrawArrays(Gl.GL_QUADS, 16, 4);

            Lefttex.Bind();
            Gl.glDrawArrays(Gl.GL_QUADS, 20, 4);

            building.Draw(transID);  // PROBLEM HERE  
            tree.Draw(transID); //passing model id but its called transid
            spider.Draw(transID);
            jeep.Draw(transID);
            house.Draw(transID);
            /*
            //triangle drawing
            GPU.BindBuffer(vertexBufferID2);
            Gl.glUniformMatrix4fv(transID, 1, Gl.GL_FALSE, modelmatrix2.to_array());
            Gl.glEnableVertexAttribArray(0);
            Gl.glVertexAttribPointer(0, 3, Gl.GL_FLOAT, Gl.GL_FALSE, 6 * sizeof(float), IntPtr.Zero);
            Gl.glEnableVertexAttribArray(1);
            Gl.glVertexAttribPointer(1, 3, Gl.GL_FLOAT, Gl.GL_FALSE, 6 * sizeof(float), (IntPtr)(3 * sizeof(float)));
            //coord
            GPU.BindBuffer(TriangleCoordID);
            Gl.glEnableVertexAttribArray(2);
            Gl.glVertexAttribPointer(2, 2, Gl.GL_FLOAT, Gl.GL_FALSE, 0, (IntPtr)(0));
            tex.Bind();
            //  Gl.glUniformMatrix4fv(transID, 1, Gl.GL_FALSE, glm.translate(new mat4(1),cam.center).to_array());
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 0, 3);

            //2nd triangle drawing
            //triangle drawing
            GPU.BindBuffer(vertexBuffer2ID2);
            Gl.glEnableVertexAttribArray(0);
            Gl.glVertexAttribPointer(0, 3, Gl.GL_FLOAT, Gl.GL_FALSE, 6 * sizeof(float), IntPtr.Zero);
            Gl.glEnableVertexAttribArray(1);
            Gl.glVertexAttribPointer(1, 3, Gl.GL_FLOAT, Gl.GL_FALSE, 6 * sizeof(float), (IntPtr)(3 * sizeof(float)));
            //coord
            GPU.BindBuffer(TriangleCoord2ID);
            Gl.glEnableVertexAttribArray(2);
            Gl.glVertexAttribPointer(2, 2, Gl.GL_FLOAT, Gl.GL_FALSE, 0, (IntPtr)(0));
            textri2.Bind(); */


            //     Gl.glUniformMatrix4fv(transID, 1, Gl.GL_FALSE, glm.translate(new mat4(1), (IntPtr)(0)));

            Gl.glDrawArrays(Gl.GL_TRIANGLES, 0, 3);
        }
        public void Update(float deltaTime)
        {
            cam.UpdateViewMatrix();
            Gl.glUniform3fv(camposID, 1, cam.GetCameraPosition().to_array());
            ProjectionMatrix = cam.GetProjectionMatrix();
            ViewMatrix = cam.GetViewMatrix();
            m.UpdateExportedAnimation();
            enemy2.UpdateExportedAnimation();
        }
        public void SendLightData(float red, float green, float blue, float attenuation, float specularExponent)
        {
            vec3 ambientLight = new vec3(red, green, blue);
            Gl.glUniform3fv(AmbientLightID, 1, ambientLight.to_array());
            vec2 data = new vec2(attenuation, specularExponent);
            Gl.glUniform2fv(DataID, 1, data.to_array());
        }
        public void CleanUp()
        {
            sh.DestroyShader();
        }
    }
}
