// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_AoeTurf_Conjure_Soulstone_Noncult : Obj_Effect_ProcHolder_Spell_AoeTurf_Conjure_Soulstone {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.summon_type = new ByTable(new object [] { typeof(Obj_Item_Device_Soulstone_Anybody) });
		}

		public Obj_Effect_ProcHolder_Spell_AoeTurf_Conjure_Soulstone_Noncult ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}