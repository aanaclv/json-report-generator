# ˚˖𓍢ִ໋❀ JSON Report Generator (.NET) 𝜗𝜚˚⋆

Project developed in **C# / .NET** designed to serve as a baseline for studying and practicing business rule validation flows, exception handling, JSON data serialization/deserialization, and analytical queries using **LINQ**.

---

## ʚɞ Features & Project Flow

The application flow simulates a robust data processing pipeline:
1. **Data Input:** Receives a list of raw objects (in this example, books).
2. **Entity Creation:** Attempts to instantiate objects applying domain validations within the constructor.
3. **Failure Handling (Resilience):** Catches business validation exceptions without interrupting the overall batch flow, storing errors separately.
4. **JSON Serialization:** Converts only the objects that passed the validation rules into a formatted JSON string (`Indented`) and saves it to disk (`report.json`).
5. **Deserialization & Reading:** Reads the generated JSON file back into the system.
6. **LINQ Analytical Report:** Processes the retrieved data to extract statistics (totals, conditional counters, averages, sorting, and category groupings).

---

## ʚɞ Technologies Used

- **.NET (C#)**
- **System.Text.Json** (Native serialization and deserialization)
- **LINQ** (Queries, aggregations, and collection manipulation)

---

## ʚɞ Folder Structure (Base)

```text
json-report-generator/
│
├── JsonReporter/
│   ├── Domain/
│   │   └── Entities/          # Domain Entities and Business Rules
│   ├── Program.cs             # Main flow, error handling, and reporting
│   └── JsonReporter.csproj    # C# project configuration file
│
└── README.md                  # Project documentation

## ✦ How to Run the Project

Make sure you have the .NET SDK installed on your machine.

1. Open your terminal (PowerShell or CMD) and navigate to the project directory:
   ```bash
   cd JsonReporter
   ```
2. Run the build and execution command:
   ```bash
   dotnet run
   ```
