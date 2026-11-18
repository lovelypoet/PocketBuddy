import type { HTMLAttributes } from 'react'

type CardProps = HTMLAttributes<HTMLElement>

export function Card({ className = '', ...props }: CardProps) {
  return (
    <section
      className={`rounded-2xl border border-mint/50 bg-cream p-8 shadow-sm ${className}`.trim()}
      {...props}
    />
  )
}
