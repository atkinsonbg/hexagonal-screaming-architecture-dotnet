-- Insert first recipe
INSERT INTO recipes (title, description, instructions)
VALUES (
    'Classic Chocolate Chip Cookies',
    'Soft and chewy chocolate chip cookies that are perfect for any occasion',
    '1. Preheat oven to 375°F\n2. Cream butter and sugars\n3. Mix in eggs and vanilla\n4. Add dry ingredients\n5. Fold in chocolate chips\n6. Bake for 10-12 minutes'
) RETURNING id;

-- Insert ingredients for first recipe
INSERT INTO ingredients (recipe_id, name, amount)
VALUES 
    ((SELECT id FROM recipes WHERE title = 'Classic Chocolate Chip Cookies'), 'All-Purpose Flour', '2 1/4 cups'),
    ((SELECT id FROM recipes WHERE title = 'Classic Chocolate Chip Cookies'), 'Butter', '1 cup'),
    ((SELECT id FROM recipes WHERE title = 'Classic Chocolate Chip Cookies'), 'Brown Sugar', '3/4 cup'),
    ((SELECT id FROM recipes WHERE title = 'Classic Chocolate Chip Cookies'), 'Chocolate Chips', '2 cups');

-- Insert second recipe
INSERT INTO recipes (title, description, instructions)
VALUES (
    'Simple Tomato Pasta',
    'Quick and easy pasta dish with fresh tomato sauce',
    '1. Boil pasta in salted water\n2. Sauté garlic in olive oil\n3. Add tomatoes and herbs\n4. Simmer for 15 minutes\n5. Combine with pasta'
) RETURNING id;

-- Insert ingredients for second recipe
INSERT INTO ingredients (recipe_id, name, amount)
VALUES 
    ((SELECT id FROM recipes WHERE title = 'Simple Tomato Pasta'), 'Spaghetti', '1 pound'),
    ((SELECT id FROM recipes WHERE title = 'Simple Tomato Pasta'), 'Fresh Tomatoes', '4 cups'),
    ((SELECT id FROM recipes WHERE title = 'Simple Tomato Pasta'), 'Garlic', '4 cloves'),
    ((SELECT id FROM recipes WHERE title = 'Simple Tomato Pasta'), 'Olive Oil', '1/4 cup'),
    ((SELECT id FROM recipes WHERE title = 'Simple Tomato Pasta'), 'Fresh Basil', '1/2 cup');