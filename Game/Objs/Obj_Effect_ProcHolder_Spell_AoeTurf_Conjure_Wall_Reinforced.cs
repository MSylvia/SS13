// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_AoeTurf_Conjure_Wall_Reinforced : Obj_Effect_ProcHolder_Spell_AoeTurf_Conjure_Wall {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.charge_max = 300;
			this.summon_type = new ByTable(new object [] { typeof(Tile_Simulated_Wall_RWall) });
		}

		public Obj_Effect_ProcHolder_Spell_AoeTurf_Conjure_Wall_Reinforced ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}