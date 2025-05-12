-- Insert first recipe
INSERT INTO recipes (title, description, instructions)
VALUES (
    'Classic Chocolate Chip Cookies',
    'Soft and chewy chocolate chip cookies that are perfect for any occasion',
    '1. Preheat oven to 375°F\n2. Cream butter and sugars\n3. Mix in eggs and vanilla\n4. Add dry ingredients\n5. Fold in chocolate chips\n6. Bake for 10-12 minutes'
);

SET @cookie_recipe_id = LAST_INSERT_ID();

-- Insert ingredients for first recipe
INSERT INTO ingredients (recipe_id, name, amount)
VALUES 
    (@cookie_recipe_id, 'All-Purpose Flour', '2 1/4 cups'),
    (@cookie_recipe_id, 'Butter', '1 cup'),
    (@cookie_recipe_id, 'Brown Sugar', '3/4 cup'),
    (@cookie_recipe_id, 'Chocolate Chips', '2 cups');

-- Insert second recipe
INSERT INTO recipes (title, description, instructions)
VALUES (
    'Simple Tomato Pasta',
    'Quick and easy pasta dish with fresh tomato sauce',
    '1. Boil pasta in salted water\n2. Sauté garlic in olive oil\n3. Add tomatoes and herbs\n4. Simmer for 15 minutes\n5. Combine with pasta'
);

SET @pasta_recipe_id = LAST_INSERT_ID();

-- Insert ingredients for second recipe
INSERT INTO ingredients (recipe_id, name, amount)
VALUES 
    (@pasta_recipe_id, 'Spaghetti', '1 pound'),
    (@pasta_recipe_id, 'Fresh Tomatoes', '4 cups'),
    (@pasta_recipe_id, 'Garlic', '4 cloves'),
    (@pasta_recipe_id, 'Olive Oil', '1/4 cup'),
    (@pasta_recipe_id, 'Fresh Basil', '1/2 cup');