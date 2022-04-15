using pencilAPI.Models;
using System.Collections.Generic;

namespace pencilAPI.tests.MockData;

public class PencilMockData {
	public static List<Pencil> GetPencils() {
		return new List<Pencil> {
			new Pencil {
				Id = "6258bd9314666920f13799d1",
				Name = "600",
				LeadSize = 0.5F,
				Colour = "Black",
				Manufacturer = new Manufacturer {
					Name = "Rotring",
					Country = "Germany",
					YearFounded = 1928
				}
			}

		};
	}
}