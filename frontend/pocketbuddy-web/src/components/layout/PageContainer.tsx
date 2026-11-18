import type { HTMLAttributes } from 'react'

type PageContainerProps = HTMLAttributes<HTMLElement>

export function PageContainer({ className = '', ...props }: PageContainerProps) {
  return <main className={`px-6 ${className}`.trim()} {...props} />
}
