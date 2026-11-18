import { render, screen } from '@testing-library/react'
import { describe, expect, it } from 'vitest'
import App from './App'

describe('App', () => {
  it('renders the PocketBuddy welcome shell', () => {
    render(<App />)

    expect(
      screen.getByRole('heading', { name: 'Your Personal Finance Companion' }),
    ).toBeInTheDocument()
  })
})
