import { PageContainer } from '../components/layout/PageContainer'
import { Card } from '../components/ui/Card'

export function HomePage() {
  return (
    <PageContainer className="flex min-h-screen items-center justify-center py-16">
      <Card className="max-w-xl text-center">
        <p className="mb-4 text-sm font-semibold tracking-[0.2em] text-forest uppercase">
          PocketBuddy
        </p>
        <h1 className="text-4xl font-semibold tracking-tight text-forest sm:text-5xl">
          Your Personal Finance Companion
        </h1>
        <p className="mt-5 text-lg leading-8 text-forest/75">
          A thoughtful space for your financial wellbeing.
        </p>
      </Card>
    </PageContainer>
  )
}
