import json

def load_json_file(file_path):
    """Loads a JSON file and returns the data."""
    try:
        with open(file_path, 'r') as file:
            data = json.load(file)
            return data
    except Exception as e:
        print(f"Error loading JSON file: {e}")
        return None

def display_books(books):
    """Displays books in a readable format."""
    for book in books:
        print(f"Title: {book.get('title', 'N/A')}")
        print(f"Author: {book.get('author', 'N/A')}")
        print(f"Condition: {book.get('condition', 'N/A')}")
        print(f"Printing: {book.get('printing', 'N/A')}")
        print(f"Cover: {book.get('cover', 'N/A')}")
        print(f"Batch: {book.get('batch', 'N/A')}")
        print(f"ISBN: {book.get('isbn', 'N/A')}")
        print("-" * 40)

def filter_books(books, key, value):
    """Filters books based on a specific key-value pair."""
    return [book for book in books if book.get(key) == value]

def main():
    file_path = input("Enter the path to the JSON file: ")
    books = load_json_file(file_path)
    
    if books is None:
        return

    print("\nAll Books:")
    print("=" * 40)
    display_books(books)

    # Example: Filter by condition
    condition_filter = input("\nEnter a condition to filter books by (or press Enter to skip): ").strip()
    if condition_filter:
        filtered_books = filter_books(books, "condition", condition_filter)
        print(f"\nBooks with condition '{condition_filter}':")
        print("=" * 40)
        display_books(filtered_books)

if __name__ == "__main__":
    main()



