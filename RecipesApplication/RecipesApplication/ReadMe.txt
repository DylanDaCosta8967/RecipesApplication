Task:

Given the available ingredients shown and the list of recipes below, determine the optimal combination of foods that can be created in order to feed as many people as possible.

Recipes:
	Burger Feeds 1:
		1x Meat
		1x Lettuce
		1x Tomato
		1x Cheese
		1x Dough
	Pasta Feeds 2:
		2x Dough
		1x Tomato
		2x Cheese
		1x Meat
	Pie Feeds 1:
		2x Dough
		2x Meat
	Salad Feeds 3:
		2x Lettuce
		2x Tomato
		1x Cucumber
		2x Cheese
		1x Olives
	Sandwich Feeds 1:
		1x Dough
		1x Cucumber
	Pizza Feeds 4:
		3x Dough
		2x Tomato
		3x Cheese
		1x Olives

Available Ingredients:
	2x Cucumber
	2x Olives
	3x Lettuce
	6x Meat
	6x Tomato
	8x Cheese
	10x Dough 

Assumptions:

	No requirement for Data entry, simple hard coded data based on Task.
	Optimal combination of foods; Least number of recipes to prepare feeding the maximum number of people. 

Approach:

	task divided into separate concerns, 

	1. Data Retrieval: Fetches recipes and their ingredients from a data source.
	2. Validation: Checks if certain combinations of recipes can be executed given the available ingredients to reduce iterations for performance.
	3. Combination Generation: Generates possible combinations of recipes based on number of recipes and the maximum number a recipe can be used based on ingredients.
	4. Optimization: Selects the best combination that feeds the most people with the least number of recipes used with the maximum number of people fed.
	5. Result Display: Outputs the best combination found to the console.

Assessment:

	At first glance this task appears to be simple however upon unpacking an applying a POC to find a solution, several combinations resulted in reaching the maximum number of people that can be feed. 

Breakdown:

	Main Class and Method
	•	Main Method: Serves as the entry point. It initializes necessary classes and starts the process of fetching data, validating combinations, generating combinations, finding the best combination, and displaying results.

	Models
	•	Recipe Class: Represents a recipe, containing fields for its name, the number of people it feeds, and a dictionary of its ingredients along with their required quantities.

	Data Management
	•	RecipeData Class: Provides methods to retrieve hardcoded lists of recipes and a dictionary of ingredients. This class simulates what would typically be database queries.

	Interfaces
	•	IRecipeValidator Interface: Defines methods for validating combinations of recipes against available ingredients and for calculating the maximum number of times a recipe can be prepared given the ingredients.
	•	ICombinationGenerator Interface: Defines methods for generating all possible combinations of recipes based on their counts and constraints like the maximum quantity per recipe.

	Helper Classes
	•	SimpleCombinationGenerator Class: Implements ICombinationGenerator. It generates all possible combinations of a given set of recipes up to a specified maximum and finds the best combination based on given criteria using the provided IRecipeValidator.
	•	RecipeValidator Class: Implements IRecipeValidator. It provides functionality to check if a combination of recipes is valid based on the available ingredients and to calculate the maximum possible times a recipe can be made.

	Process Flow in Main
	1.	Initialization: Instances of RecipeData, RecipeValidator, and SimpleCombinationGenerator are created.
	2.	Data Fetching: GetRecipes and GetIngredients methods are called to retrieve recipes and ingredients, respectively.
	3.	Combination Validation and Generation:
		•	The maximum number of times each recipe can be prepared is calculated.
		•	All possible combinations of recipes based on the maximum limits are generated.
	4.	Optimization:
		•	Among all generated combinations, the one that maximizes the number of people fed while using the fewest recipes and the fewest quantities of ingredients is identified.
	5.	Display: The best combination, if found, is printed. If not, a message indicating no valid combinations were found is displayed.

	Error Handling and Validation
	•	Checks in the IsValidCombination and other methods ensure that no null values are processed, preventing runtime errors and ensuring that operations are performed only on valid data.

