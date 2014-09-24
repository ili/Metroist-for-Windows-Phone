using MetroistLib.Model;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metroist
{
    class TileManager
    {
        private static Dictionary<Project, ShellTile> Tiles = new Dictionary<Project,ShellTile>();

        public static void CreateOrUpdateTileForProject(Project project, int count)
        {
            StandardTileData NewTileData = new StandardTileData
            {
                Title = project.name,
                BackgroundImage = null,
                Count = count,
                BackTitle = project.name,
                BackBackgroundImage = null,
                BackContent = "You have uncompleted tasks for today"
            };

            if (!Tiles.Keys.Select(key => key == project).FirstOrDefault())
            {
                ShellTile.Create(new Uri("/SecondaryTile.xaml?Project=", UriKind.Relative), NewTileData);
                string IdentifyFromString = String.Format("ProjectName={0}&ProjectId={1}", project.name, project.id); 
                ShellTile TileOfProjectCreated = 
                    ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains(IdentifyFromString));
                Tiles.Add(project, TileOfProjectCreated);
            }
            else
            {
                Tiles[project].Update(NewTileData);
            }
        }
    }
}
