using Aspose.Diagram.AutoLayout;
using Aspose.Diagram.Manipulation;
using Aspose.Diagram;
using Aspose.Diagram.Saving;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_Management.Views
{
    public partial class Organigramme : Form
    {
        public Organigramme()
        {
            InitializeComponent();
        }

        private void Organigramme_Load(object sender, EventArgs e)
        {
            // Charger des maîtres à partir de n'importe quel diagramme, gabarit ou modèle existant
            string visioStencil = "Basic Shapes.vss";
            const string rectangleMaster = "Rectangle";
            const string connectorMaster = "Dynamic connector";
            const int pageNumber = 0;
            const double width = 1;
            const double height = 1;
            double pinX = 4.25;
            double pinY = 9.5;
            // Définir des valeurs pour construire la hiérarchie
            List<string> listPos = new List<string>(new string[] { "0", "0:0", "0:1", "0:2", "0:3", "0:4", "0:5", "0:6", "0:0:0", "0:0:1", "0:3:0", "0:3:1", "0:3:2", "0:6:0", "0:6:1" });
            // Définissez une table de hachage pour mapper le nom de la chaîne à un identifiant de forme longue
            Hashtable shapeIdMap = new Hashtable();
            // Créer un nouveau diagramme
            Diagram diagram = new Diagram(visioStencil);
            foreach (string orgnode in listPos)
            {
                // Ajouter une nouvelle forme de rectangle
                long rectangleId = diagram.AddShape(pinX++, pinY++, width, height, rectangleMaster, pageNumber);
                // Définir les propriétés de la nouvelle forme
                Shape shape = diagram.Pages[pageNumber].Shapes.GetShape(rectangleId);
                shape.Text.Value.Add(new Txt(orgnode));
                shape.Name = orgnode;
                shapeIdMap.Add(orgnode, rectangleId);
            }
            // Créer des connexions entre les nœuds
            foreach (string orgName in listPos)
            {
                int lastColon = orgName.LastIndexOf(':');
                if (lastColon > 0)
                {
                    string parendName = orgName.Substring(0, lastColon);
                    long shapeId = (long)shapeIdMap[orgName];
                    long parentId = (long)shapeIdMap[parendName];
                    Shape connector1 = new Shape();
                    long connecter1Id = diagram.AddShape(connector1, connectorMaster, pageNumber);
                    diagram.Pages[pageNumber].ConnectShapesViaConnector(parentId, ConnectionPointPlace.Right,
                        shapeId, ConnectionPointPlace.Left, connecter1Id);
                }
            }

            //organigramme de mise en page automatique
            LayoutOptions flowChartOptions = new LayoutOptions
            {
                LayoutStyle = LayoutStyle.FlowChart,
                Direction = LayoutDirection.TopToBottom,
                EnlargePage = true
            };

            diagram.Pages[pageNumber].Layout(flowChartOptions);

            // Enregistrer le diagramme
            diagram.Save("FlowChart_out.vsdx", SaveFileFormat.VSDX);

        }
    }
}