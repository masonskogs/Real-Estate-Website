import { useEffect, useState } from 'react'
import './App.css'
import Tile from '../src/Components/Tile/Tile'
import type { PropertyListing } from './dataTypes'
import uuid from 'react-uuid'

function App() {
  const [propertyListingResult, setPropertyListingResult] = useState<PropertyListing[]>([])

  useEffect(() => {
    fetch('https://localhost:7263/api/PropertyListings')
      .then(response => response.json())
      .then(data => {
        console.log(data)
        setPropertyListingResult(data)
      })
  }, [])

  return (
    <>
      {propertyListingResult.length > 0 ? (
        propertyListingResult.map((result) => (
          <Tile
            type={result.propertyType}
            key={uuid()}
            value={"$" + result.propertyValue}
            info={result.propertyInfo}
          />
        ))
      ) : (
        <p>
          No property listings available.
        </p>
      )}
    </>
  )
}

export default App