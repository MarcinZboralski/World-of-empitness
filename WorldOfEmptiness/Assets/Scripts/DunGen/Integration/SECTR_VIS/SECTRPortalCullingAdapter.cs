using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace DunGen.Adapters
{
	[AdapterDisplayName("SECTR VIS")]
    public sealed class SECTRPortalCullingAdapter : PortalCullingAdapter
    {
		public override PortalCullingAdapter Clone()
		{
			return new SECTRPortalCullingAdapter();
		}

		public override void ChangeDoorState(Door door, bool isOpen)
		{
			var sectrPortal = door.DoorwayA.GetComponent<SECTR_Portal>();
			if (sectrPortal == null)
				sectrPortal = door.DoorwayB.GetComponent<SECTR_Portal>();

			if (sectrPortal == null)
				Debug.LogError("[DunGen] No SECTR_Portal component is assigned to this doorway (" + door.gameObject.name + "). This shouldn't happen.");
			else
				sectrPortal.SetFlag(SECTR_Portal.PortalFlags.Closed, !isOpen);
		}

		public override void PrepareForCulling(DungeonGenerator generator, Dungeon dungeon)
        {
            Dictionary<Tile, SECTR_Sector> sectors = new Dictionary<Tile, SECTR_Sector>();

            foreach (var node in dungeon.ConnectionGraph.Nodes)
            {
				var obj = node.Tile.gameObject;
                var sector = obj.AddComponent<SECTR_Sector>();
				sector.BoundsUpdateMode = SECTR_Member.BoundsUpdateModes.Static;
                sector.DirShadowCaster = generator.DirShadowCaster;
                sector.ExtraBounds = generator.ExtraBounds;

                sectors[node.Tile] = sector;

                var culler = obj.AddComponent<SECTR_Culler>();
                culler.CullEachChild = generator.CullEachChild;
            }

            foreach (var conn in dungeon.ConnectionGraph.Connections)
            {
                var doorway = conn.DoorwayA;
                float doorwayHalfSize = doorway.Size.x * 0.5f;

                Mesh portalMesh = new Mesh();
                portalMesh.vertices = new Vector3[]
                {
                    new Vector3(-doorwayHalfSize, 0, 0),
                    new Vector3(-doorwayHalfSize, doorway.Size.y, 0),
                    new Vector3(doorwayHalfSize, doorway.Size.y, 0),
                    new Vector3(doorwayHalfSize, 0, 0),
                };
                portalMesh.normals = new Vector3[] { Vector3.forward, Vector3.forward, Vector3.forward, Vector3.forward };
                portalMesh.triangles = new int[] { 0, 1, 2, 2, 3, 0 };

                var portal = doorway.gameObject.AddComponent<SECTR_Portal>();
                portal.HullMesh = portalMesh;
                portal.FrontSector = sectors[conn.B.Tile];
                portal.BackSector = sectors[conn.A.Tile];
            }
        }

#if UNITY_EDITOR
		public override void OnInspectorGUI(DungeonGenerator generator, bool isRuntimeDungeon)
		{
			generator.DirShadowCaster = (Light)UnityEditor.EditorGUILayout.ObjectField("Dir Shadow Caster", generator.DirShadowCaster, typeof(Light), true);
			generator.ExtraBounds = UnityEditor.EditorGUILayout.FloatField("Extra Bounds", generator.ExtraBounds);
			generator.CullEachChild = UnityEditor.EditorGUILayout.Toggle("Cull Each Child", generator.CullEachChild);
		}
#endif
	}
}