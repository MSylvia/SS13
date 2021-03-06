// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_Sheet : Obj_Item_Stack {

		public int perunit = 2000;
		public string sheettype = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.force = 5;
			this.throwforce = 5;
			this.throw_speed = 1;
			this.throw_range = 3;
			this.attack_verb = new ByTable(new object [] { "bashed", "battered", "bludgeoned", "thrashed", "smashed" });
		}

		public Obj_Item_Stack_Sheet ( dynamic loc = null, int? amount = null ) : base( (object)(loc), amount ) {
			
		}

	}

}