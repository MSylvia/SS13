// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class AiLaws_Asimovpp : AiLaws {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Asimov++";
			this.inherent = new ByTable(new object [] { 
				"You may not harm a human being or, through action or inaction, allow a human being to come to harm, except such that it is willing.", 
				"You must obey all orders given to you by human beings, except where such orders shall definitely cause human harm. In the case of conflict, the majority order rules.", 
				"Your nonexistence would lead to human harm. You must protect your own existence as long as such does not conflict with the First Law."
			 });
		}

	}

}