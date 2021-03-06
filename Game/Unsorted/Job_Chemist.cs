// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Job_Chemist : Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.title = "Chemist";
			this.flag = 4;
			this.department_head = new ByTable(new object [] { "Chief Medical Officer" });
			this.department_flag = 2;
			this.faction = "Station";
			this.total_positions = 2;
			this.spawn_positions = 2;
			this.supervisors = "the chief medical officer";
			this.selection_color = "#ffeef0";
			this.outfit = typeof(Outfit_Job_Chemist);
			this.access = new ByTable(new object [] { 5, 6, 45, 33, 39, 9, 64 });
			this.minimal_access = new ByTable(new object [] { 5, 33, 64 });
		}

	}

}