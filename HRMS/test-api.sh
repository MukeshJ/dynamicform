#!/bin/bash

echo "🚀 HRMS API Test Script"
echo "======================"

# Build the solution
echo "📦 Building the solution..."
dotnet build

if [ $? -eq 0 ]; then
    echo "✅ Build successful!"
else
    echo "❌ Build failed!"
    exit 1
fi

# Run the API in background
echo "🌐 Starting the API server..."
cd HRMS.API
dotnet run --urls="http://localhost:5000" > api.log 2>&1 &
API_PID=$!

# Wait for API to start
echo "⏳ Waiting for API to start..."
sleep 10

# Test if API is running
echo "🧪 Testing API endpoints..."

# Test health/swagger
echo "Testing Swagger UI..."
curl -s -o /dev/null -w "%{http_code}" http://localhost:5000/swagger/index.html
echo ""

# Test a simple API endpoint
echo "Testing API base endpoint..."
curl -s -o /dev/null -w "%{http_code}" http://localhost:5000/api/employees
echo ""

echo "📊 API server logs (last 20 lines):"
tail -20 api.log

# Clean up
echo "🧹 Cleaning up..."
kill $API_PID 2>/dev/null

echo "✨ Test completed!"